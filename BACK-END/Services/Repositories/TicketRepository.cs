using AutoMapper;
using BACK_END.Data;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class TicketRepository : ITicket
    {
        private readonly BACK_ENDContext _db;
        private readonly IMapper _mapper;
        private readonly IAuth _auth;
        private readonly FirebaseStorageService _firebase;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TicketRepository(BACK_ENDContext db, IMapper mapper, IAuth auth, FirebaseStorageService firebase, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _mapper = mapper;
            _auth = auth;
            _firebase = firebase;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<DTOs.Ticket.TicketPagination?> GetAllTicketByRoleAsync(DTOs.Ticket.TicketQuery ticketQuery)
        {
            var user = await _auth.GetUserByToken(ticketQuery.Token);
            if (user == null)
            {
                return null;
            }

            IQueryable<Ticket> data = _db.Ticket.Include(x => x.Images).OrderByDescending(x => x.CreateDate);
            if (user.Role == "Admin")
            {
                var removeTickets = data.Where(x => x.MotelId != null && (x.Type == 2 || x.Type == 4)).Select(x => x.Id);
                data = data.Where(x => !removeTickets.Contains(x.Id));
            }
            else if (user.Role == "Staff")
            {
                data = data.Where(x => x.Receiver == user.Id.ToString());
            }
            else if (user.Role == "Owner")
            {
                var motelIds = await _db.Motel
                        .Where(x => x.UserId == user.Id)
                        .Select(x => x.Id)
                        .ToListAsync();
                data = data.Where(x => x.MotelId.HasValue
                    && motelIds.Contains(x.MotelId.Value)
                    && x.Type != 1
                    && x.Type != 3);
            }
            else
            {
                return null;
            }

            if (ticketQuery.Status > 0)
            {
                data = data.Where(x => x.Status == ticketQuery.Status);
            }

            if (!string.IsNullOrEmpty(ticketQuery.Search))
            {
                data = data.Where(x => x.Title.ToLower().Contains(ticketQuery.Search.ToLower()));
            }

            var page = await PagedList<Ticket>.CreateAsync(data, ticketQuery.PageNumber, ticketQuery.PageSize);

            var paginationResult = _mapper.Map<DTOs.Ticket.TicketPagination>(page);

            return paginationResult;
        }

        public async Task<DTOs.Ticket.Infoticket?> GetTicketByIdAsync(DTOs.Ticket.InfoticketQuery infoticketQuery)
        {
            var user = await _auth.GetUserByToken(infoticketQuery.Token);
            if (user == null)
            {
                return null;
            }
            IQueryable<Ticket> data = _db.Ticket
                .Include(x => x.Images)
                .Include(x => x.User);
            if (user.Role == "Admin")
            {
                var removeTickets = data.Where(x => x.MotelId != null && (x.Type == 2 || x.Type == 4)).Select(x => x.Id);
                data = data.Where(x => !removeTickets.Contains(x.Id));
            }
            else if (user.Role == "Staff")
            {
                data = data.Where(x => x.Receiver == user.Id.ToString());
            }
            else if (user.Role == "Owner")
            {
                var motelIds = await _db.Motel
                        .Where(x => x.UserId == user.Id)
                        .Select(x => x.Id)
                        .ToListAsync();
                data = data.Where(x => x.MotelId.HasValue
                    && motelIds.Contains(x.MotelId.Value)
                    && x.Type != 1
                    && x.Type != 3);
            }
            else
            {
                return null;
            }
            var ticket = await data.FirstOrDefaultAsync(x => x.Id == infoticketQuery.Id);
            if (ticket != null)
            {
                var map = _mapper.Map<DTOs.Ticket.Infoticket>(ticket);
                return map;
            }
            return null;
        }

        public async Task<IEnumerable<DTOs.Ticket.Receiver>?> GetReceiverAsync(string? roleName)
        {
            var emails = await _auth.GetEmailsByRoleAsync(roleName);
            if (emails != null)
            {
                var users = await _db.User.Where(x => emails.Contains(x.Email)).ToListAsync();
                var map = _mapper.Map<List<DTOs.Ticket.Receiver>>(users);
                return map;
            }
            return null;
        }

        public async Task<DTOs.Ticket.Tickets?> CreateTicketAsync(DTOs.Ticket.Create data)
        {
            var user = await _auth.GetUserByToken(data.Token);
            if (user != null)
            {
                var ticket = new Ticket()
                {
                    Type = data.Type,
                    Title = data.Title,
                    Content = data.Content,
                    CreateDate = DateTime.Now,
                    Status = 1,
                    UserId = user.Id,
                    MotelId = data.MotelId
                };
                if (await _roleManager.RoleExistsAsync("Admin"))
                {
                    var usersInRole = await _userManager.GetUsersInRoleAsync("Admin");
                    var firstAdminUser = usersInRole.FirstOrDefault();
                    var admin = await _db.User.FirstOrDefaultAsync(x => x.Email == firstAdminUser.Email);
                    if (string.IsNullOrEmpty(data.Receiver) && admin != null)
                    {
                        ticket.Receiver = admin.Id.ToString();
                    }
                }
                var result = await _db.Ticket.AddAsync(ticket);
                await _db.SaveChangesAsync();
                if (data.imgs != null && data.imgs.Count() > 0 && data.imgs.Count() <= 4)
                {
                    foreach (var item in data.imgs)
                    {
                        var url = await _firebase.UploadFileAsync(item);
                        if (!string.IsNullOrEmpty(url))
                        {
                            var img = new Image()
                            {
                                Link = url,
                                Type = item.ContentType,
                                TicketId = result.Entity.Id
                            };
                            await _db.Image.AddAsync(img);
                            await _db.SaveChangesAsync();
                        }
                    }
                }
                var map = _mapper.Map<DTOs.Ticket.Tickets>(result.Entity);
                return map;
            }
            return null;
        }

        public async Task<Ticket?> UpdateTicketAsync(DTOs.Ticket.Update data)
        {
            var exist = await _db.Ticket.FirstOrDefaultAsync(x => x.Id == data.Id);
            if (exist != null)
            {
                if (data.Status != 0)
                {
                    exist.Status = data.Status;
                }
                if (data.Receiver != null)
                {
                    exist.Receiver = data.Receiver;
                }
                await _db.SaveChangesAsync();
            }
            return exist;
        }
    }
}
