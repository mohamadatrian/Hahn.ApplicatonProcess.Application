import { Aurelia, PLATFORM } from 'aurelia-framework';
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
        }]);


        this.router = router;
    }
}
