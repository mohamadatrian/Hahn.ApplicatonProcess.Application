import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class List {
    public users: User[];
    http: HttpClient;
    constructor(http: HttpClient) {
        this.http = http;
        this.http.baseUrl = 'api/user/';
        this.getAll();
    }
    getAll() {
        this.http.fetch('')
            .then(result => result.json() as Promise<User[]>)
            .then(data => {
                this.users = data;
            });
    }

    delete(id: number) {
        this.http.fetch(`${id}`, {
            method: 'DELETE'
        }).then(response => {
            this.getAll();
        });
    }
}
