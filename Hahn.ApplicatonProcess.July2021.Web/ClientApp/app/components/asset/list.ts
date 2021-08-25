import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class List {
    assets: Asset[];
    http: HttpClient;
    constructor(http: HttpClient) {
        this.http = http;
        this.getAll();
        this.assets = [];
    }
    getAll() {
        this.http.fetch('asset/')
            .then(result => result.json() as Promise<Asset[]>)
            .then(data => {
                this.assets = data;
            });
    }
}
