import axios from 'axios';
import React, { createContext, useContext, useEffect, useState } from 'react';
import {useSubscription,  notify } from '../hooks/use-subscription';
import { AuthData, LoginDto, User, CreateUserDto } from './authentication';

const AuthContext = createContext<AuthData>(null);

const fetchUser = async (cb: (user: User) => void) => {
    axios.get<User>(`/api/authentication/me`, { validateStatus: (status) => ((status >= 200 && status < 300) || status === 401) })
            .then((response) => cb(response.data))
            .catch((error) => {
                console.error("Error while fetching current user", error);
            });
}

export const loginUser = (loginDto: LoginDto) => axios.post<User>(`/api/authentication/login`, loginDto).then((response) => {
    notify("user-login", undefined);
    return response;
});

export const logoutUser = () => axios.post(`/api/authentication/logout`).then((response) => {
    notify("user-logout", undefined);
    return response;
});

export const AuthProvider: React.FC<React.PropsWithChildren> = (props) => {
    const [user, setUser] = useState<AuthData>(null);

    useEffect(() => {
        fetchUser(setUser);
    }, []);

    useSubscription("user-login", () => {
        fetchUser(setUser);
    });

    useSubscription("user-logout", () => {
        setUser(null);
    });

    return (
        <AuthContext.Provider value={user}>
            {props.children}
        </AuthContext.Provider>
    );
}

export const useUser = () => {
    return useContext(AuthContext);
}

export const createUser = (CreateUserDto: CreateUserDto) => axios.put<User>(`/api/users`, CreateUserDto).then((response) => {
    notify("create-user", undefined);
    return response;
});