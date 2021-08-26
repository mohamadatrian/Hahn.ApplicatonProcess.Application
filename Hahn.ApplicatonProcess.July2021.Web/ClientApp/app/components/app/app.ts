import { DialogService } from 'aurelia-dialog';
import { PLATFORM, inject } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';
import { HttpClient } from 'aurelia-fetch-client';
import { FetchClientInterceptor } from '../../util/FetchClientInterceptor';
@inject(HttpClient, DialogService)
export class App {
  //constructor(httpClient: HttpClient, dialogService: DialogService) {
  //  httpClient.configure((config) => {
  //    config.useStandardConfiguration()
  //      .withInterceptor(new FetchClientInterceptor(dialogService));
  //  });
  //}

  router: Router;

  public configureRouter(config: RouterConfiguration, router: Router): Promise<void> | PromiseLike<void> | void {
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
      route: 'user/add',
      name: 'useradd',
      moduleId: PLATFORM.moduleName('../user/create'),
      nav: false,
      title: 'add user'
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
