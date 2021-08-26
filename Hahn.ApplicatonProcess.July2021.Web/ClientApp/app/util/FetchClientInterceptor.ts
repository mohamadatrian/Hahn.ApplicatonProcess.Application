import { DialogService } from "aurelia-dialog";
import { Interceptor } from "aurelia-fetch-client";
import { inject } from "aurelia-framework";
import { ErrorDialog } from "../dialog/errorDialog";

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
        return response;
    }

    requestError(request: Request) {
        return request;
    }

    responseError(response: Response) {
        response.json().then((serverError) => {
            if (serverError)
                this.dialogService.open({ viewModel: ErrorDialog, model: serverError, lock: false });
        });

        return response;
    }
}