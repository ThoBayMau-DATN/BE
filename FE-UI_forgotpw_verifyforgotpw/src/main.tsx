import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { store } from './redux/store.ts'
import { Provider } from 'react-redux'

import './index.css'
import App from './App'
import GlobalStyles from './components/global_style/index'
import { ThemeProvider } from './components/theme/themeContex.tsx'


createRoot(document.getElementById('root')!).render(
  <Provider store={store}>
    <StrictMode>
      <ThemeProvider>
        <GlobalStyles>
          <App />
        </GlobalStyles>
      </ThemeProvider>
    </StrictMode>
  </Provider>,
)
