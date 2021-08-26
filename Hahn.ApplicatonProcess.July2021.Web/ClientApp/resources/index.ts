import { DialogService } from 'aurelia-dialog';
import { HttpClient, HttpClientConfiguration } from 'aurelia-fetch-client';
import {FrameworkConfiguration} from 'aurelia-framework';
import { FetchClientInterceptor } from '../app/util/FetchClientInterceptor';

export function configure(config: FrameworkConfiguration): void {
  //config.globalResources([]);
  const http = new HttpClient();
  http.configure((c: HttpClientConfiguration) => {
    c.useStandardConfiguration()
      .withBaseUrl("api/")
      .withInterceptor(new FetchClientInterceptor(config.container.get(DialogService)));
  });

  config.container.registerInstance(HttpClient, http);
}
