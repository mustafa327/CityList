import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { getBaseUrl } from '../../main';

@Component({
  selector: 'app-city-page',
  templateUrl: './city-page.html'
})
export class CityPageComp {
  @Input() cityNameInput: string = "";
  public cityNames: Array<string> = []
  public httpcl: HttpClient | undefined;
  public apiURL: string | undefined;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpcl = http;
    this.apiURL = baseUrl;
    http.get<Array<string>>(baseUrl + 'city/ListCity').subscribe(result => {
      this.cityNames = result;
    }, error => console.error(error));
  }

  addCity(city: string)
  {
    this.httpcl?.get(this.apiURL + 'city/AddCity?cityName=' + city).subscribe(result => {
      location.reload();
    }, error => location.reload());
  }

  removeCity(city: string) {
    this.httpcl?.get(this.apiURL + 'city/RemoveCity?cityName=' + city).subscribe(result => {
      location.reload();
    }, error => location.reload());
  }
}
