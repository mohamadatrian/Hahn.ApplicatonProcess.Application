import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Details {
    public asset: Asset;
    http: HttpClient;
    constructor(http: HttpClient) {
        this.http = http;
    }

    activate(params:any) {
        return this.http.fetch(`asset/${params.id}`)
            .then(result => result.json() as Promise<Asset>)
            .then(data => {
                this.asset = data;
            });
    }
}
