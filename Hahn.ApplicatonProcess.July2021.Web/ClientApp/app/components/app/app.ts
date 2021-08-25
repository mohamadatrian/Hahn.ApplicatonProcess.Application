import { PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Hahn.ApplicatonProcess.July2021.Web';
        config.map([{
            route: ['', 'home'],
            name: 'home',
            settings: { icon: 'home' },
            moduleId: PLATFORM.moduleName('../home/home'),
            nav: true,
            title: 'Home'
        }, {
            route: 'user/list',
            name: 'userlist',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../user/list'),
            nav: true,
            title: 'user list'
        }, {
            route: 'user/details/:id',
            name: 'userdetails',
            moduleId: PLATFORM.moduleName('../user/details'),
            nav: false,
            title: 'user details'
        }, {
            route: 'user/edit/:id',
            name: 'useredit',
            moduleId: PLATFORM.moduleName('../user/edit'),
            nav: false,
            title: 'user edit'
        }, {
            route: 'asset/list',
            name: 'assetlist',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../asset/list'),
            nav: true,
            title: 'asset list'
        }, {
            route: 'asset/details/:id',
            name: 'assetdetails',
            moduleId: PLATFORM.moduleName('../asset/details'),
            nav: false,
            title: 'asset details'
        }, {
            route: 'asset/addtouser/:id',
            name: 'assetadd',
            moduleId: PLATFORM.moduleName('../asset/create'),
            nav: false,
            title: 'add asset to user'
        }]);

        this.router = router;
    }
}
