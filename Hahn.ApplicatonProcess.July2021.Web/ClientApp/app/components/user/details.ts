import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Details {
    user: User;
    http: HttpClient;
    constructor(http: HttpClient) {
        this.http = http;
    }

    activate(params) {
        return this.http.fetch(`user/${params.id}`)
            .then(result => result.json() as Promise<User>)
            .then(data => {
                this.user = data;
            });
    }
}
