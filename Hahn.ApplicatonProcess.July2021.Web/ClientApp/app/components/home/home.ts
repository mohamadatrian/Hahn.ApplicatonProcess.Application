import { DialogService } from "aurelia-dialog";
import { HttpClient, HttpClientConfiguration } from "aurelia-fetch-client";
import { inject } from "aurelia-framework";
import { FetchClientInterceptor } from "../../util/FetchClientInterceptor";

@inject(HttpClient, DialogService)
export class Home {

    constructor(httpClient: HttpClient, dialogService: DialogService) {
        httpClient.configure((config: HttpClientConfiguration) => {
            config.useStandardConfiguration()
                .withBaseUrl("api/")
                .withInterceptor(new FetchClientInterceptor(dialogService));
        });
    }
}
