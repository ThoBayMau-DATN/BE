import { Controller, Control, FieldErrors } from "react-hook-form"
import { ErrorMessage } from "@hookform/error-message"
import clsx from "clsx"

import style from '@/pages/login/styles/Login.module.scss'

interface InputFieldProps {
    control: Control<any>,
    label: string,
    name: string,
    type?: string,
    errors: FieldErrors<any>,
    classname: string
}

const InputField: React.FC<InputFieldProps> = ({ control, label, name, type = "text", errors, classname }) => {
    return (
        <>
            <label className="form-label">{label}</label>
            <Controller
                name={name}
                control={control}
                render={({ field }) =>
                    <input {...field}
                        type={type}
                        className={classname}
                    />
                }
            />
            <ErrorMessage
                errors={errors}
                name={name}
                render={({ message }) =>
                    <div className={clsx('invalid-feedback', style.err)}>{message}</div>
                }
            />
        </>
    )
}

export default InputField