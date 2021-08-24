import { DialogService } from "aurelia-dialog";
import { Interceptor } from "aurelia-fetch-client";
import { inject } from "aurelia-framework";

@inject(DialogService)
export class FetchClientInterceptor implements Interceptor {
    dialogService: DialogService;

    constructor(dialogService: DialogService) {
        this.dialogService = dialogService;
    }

    request(request: Request) {
        return request;
    }

    response(response: Response) {
        if (!response.ok)
            this.dialogService.open({ viewModel: Error, model: response, lock: false });
        return response;
    }

    requestError(request: Request) {
        return request;
    }

    responseError(response: Response) {
        return response;
    }
}