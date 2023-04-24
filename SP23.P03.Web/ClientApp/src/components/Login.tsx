import { Field, Form, Formik, FormikHelpers } from "formik";
import React, { useState } from "react";
import { Button, Input, Modal, ModalProps } from "semantic-ui-react";
import {useSubscription,  notify } from "../hooks/use-subscription";
import { LoginDto } from "./authentication";
import { loginUser } from "./AuthFunction";
import './ModalStyle.css'
import { openSignup } from "./Signup";

export const openLogin = () => {
    notify("open-user-login", undefined);
}

const Login = (props: ModalProps) => {
    const [loginOpen, setLoginOpen] = useState(false);
    const [loading, setLoading] = useState(false);

    useSubscription("open-user-login", () => {
        setLoginOpen(true);
    });

    const onSubmit = async (values: LoginDto, formikHelpers: FormikHelpers<LoginDto>) => {
        setLoading(true);
        loginUser(values)
            .then(() => {
                setLoading(false);
                setLoginOpen(false);
                formikHelpers.resetForm();
            })
            .catch((error) => {
                setLoading(false);
                console.error(error);
                alert("Login failed.");
            });
    }

    const INITIAL_VALUES: LoginDto = {userName: "", password: ""}
    return (
        <Formik initialValues={INITIAL_VALUES} onSubmit={onSubmit}>
            <Modal {...props}
                size='mini'
                open={loginOpen}
                onOpen={() => setLoginOpen(true)}
                onClose={() => setLoginOpen(false)}
                as={Form}
            >
                <div className="modal-header">
                    <h5 className="modal-title w-100 text-center" id="exampleModalLabel">
                        Login
                    </h5>
                </div>
                <div className="modal-body justify-content-center">
                    <div className="field-label">
                        <label htmlFor="userName">Username</label>
                    </div>
                    <Field as={Input} id="userName" name="userName" className="field" />
                    <div className="field-label">
                        <label htmlFor="password">Password</label>
                    </div>
                    <Field as={Input} id="password" name="password" type="password" className="field" />
                </div>
                <div className="modal-footer justify-content-between">
                    <Button type="submit" class="btn btn-danger" color="green" loading={loading}>
                         Login
                    </Button>
                    <Button onClick={() => setLoginOpen(false)} class="btn btn-secondary" data-dismiss="modal">
                         Cancel
                    </Button>
                    <Button onClick={(openSignup)} class="btn btn-primary" color="yellow">
                        Register
                    </Button>
                </div>
            </Modal>
            
        </Formik>
    );
}

export default Login;