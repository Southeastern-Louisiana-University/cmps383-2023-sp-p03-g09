import { Field, Form, Formik, FormikHelpers } from "formik";
import React, { useState } from "react";
import { Button, Input, Modal, ModalProps } from "semantic-ui-react";
import {useSubscription,  notify } from "../hooks/use-subscription";
import { CreateUserDto } from "./authentication";
import { createUser } from "./AuthFunction";
import './ModalStyle.css'

export const openSignup = () => {
    notify("open-user-signup", undefined);
}

const Signup = (props: ModalProps) => {
    const [signupOpen, setSignupOpen] = useState(false);
    const [loading, setLoading] = useState(false);

    useSubscription("open-user-signup", () => {
        setSignupOpen(true);
    });

    const onSubmit = async (values: CreateUserDto, formikHelpers: FormikHelpers<CreateUserDto>) => {
        setLoading(true);
        createUser(values)
            .then(() => {
                setLoading(false);
                setSignupOpen(false);
                formikHelpers.resetForm();
            })
            .catch((error) => {
                setLoading(false);
                console.error(error);
                alert("Signup failed.");
            });
    }

    const INITIAL_VALUES: CreateUserDto = {userName: "", password: ""}
    return (
        <Formik initialValues={INITIAL_VALUES} onSubmit={onSubmit}>
            <Modal {...props}
                size='mini'
                open={signupOpen}
                onOpen={() => setSignupOpen(true)}
                onClose={() => setSignupOpen(false)}
                as={Form}
            >
                <div className='modal-header'>
                    <h5 className="modal-title w-100 text-center" id="exampleModalLabel">
                        Create Account
                    </h5>
                </div>
                <div className='modal-body'>
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
                    <Button type="submit" class="btn btn-primary" color="green" loading={loading}>
                         Create Account
                    </Button>
                    <Button class="btn btn-secondary" onClick={() => setSignupOpen(false)}>
                         Cancel
                    </Button>
                </div>
            </Modal>
            
        </Formik>
    );
}

export default Signup;