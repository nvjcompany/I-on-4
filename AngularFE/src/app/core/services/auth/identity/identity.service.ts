import { Injectable } from '@angular/core';

@Injectable()
export class IdentityService
{
    public logout()
    {
        localStorage.removeItem('AUTH_TOKEN');
        localStorage.removeItem('ROLE');
    }

    public setToken(token: string): void
    {
        localStorage.setItem('AUTH_TOKEN', token);
    }

    public getToken(): string
    {
        return localStorage.getItem('AUTH_TOKEN');
    }

    public setRole(role: string): void
    {
        localStorage.setItem('ROLE', role);
    }

    public getRole(): string
    {
        return localStorage.getItem('ROLE');
    }

    public isLoggedIn() : boolean
    {
        if(this.getRole() && this.getToken())
        {
            return true;
        }

        return false;
    }
}