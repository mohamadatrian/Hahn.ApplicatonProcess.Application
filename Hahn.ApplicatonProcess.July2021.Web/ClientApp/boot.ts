import "bootstrap/dist/css/bootstrap.css";
import "bootstrap";
import "font-awesome/css/font-awesome.css";
import 'isomorphic-fetch';
import { Aurelia, PLATFORM } from 'aurelia-framework';
declare const IS_DEV_BUILD: boolean; // The value is supplied by Webpack during the build



export function configure(aurelia: Aurelia) {
    aurelia.use.standardConfiguration()
        .feature(PLATFORM.moduleName('resources/index'))
        .plugin(PLATFORM.moduleName('aurelia-validation'))
        .plugin(PLATFORM.moduleName('aurelia-dialog'));

    if (IS_DEV_BUILD) {
        aurelia.use.developmentLogging();
    }

    aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app/components/app/app')));
}


