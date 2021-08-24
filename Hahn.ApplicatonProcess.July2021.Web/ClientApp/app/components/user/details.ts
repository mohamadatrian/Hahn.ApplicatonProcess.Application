import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Details {
    public user: User | undefined;
    http: HttpClient;
    constructor(http: HttpClient) {
        this.http = http;
    }

    activate(params:any) {
        return this.http.fetch(`${params.id}`)
            .then(result => result.json() as Promise<User>)
            .then(data => {
                this.user = data;
            });
    }
}
