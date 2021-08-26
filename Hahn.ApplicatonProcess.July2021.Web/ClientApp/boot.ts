import "bootstrap/dist/css/bootstrap.css";
import "bootstrap";
import "font-awesome/css/font-awesome.css";
import 'isomorphic-fetch';
import { Aurelia, Container, PLATFORM } from 'aurelia-framework';
import { HttpClient, HttpClientConfiguration } from 'aurelia-fetch-client';
import { DialogService } from 'aurelia-dialog';
import { FetchClientInterceptor } from './app/util/FetchClientInterceptor';
declare const IS_DEV_BUILD: boolean; // The value is supplied by Webpack during the build


function configureContainer(container: Container) {
    const http = new HttpClient();
    http.configure((config: HttpClientConfiguration) => {
        config.useStandardConfiguration()
            .withBaseUrl("api/");
            //.withInterceptor(new FetchClientInterceptor(container.get(DialogService)));
    });

    container.registerInstance(HttpClient, http);
}

export function configure(aurelia: Aurelia) {
    aurelia.use.standardConfiguration()
        .plugin(PLATFORM.moduleName('aurelia-validation'))
        .plugin(PLATFORM.moduleName('aurelia-dialog'));

    configureContainer(aurelia.container);
    if (IS_DEV_BUILD) {
        aurelia.use.developmentLogging();
    }

    aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app/components/app/app')));
}


