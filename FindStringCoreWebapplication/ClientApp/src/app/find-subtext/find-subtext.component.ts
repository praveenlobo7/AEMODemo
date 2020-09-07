import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-find-subtext',
  templateUrl: './find-subtext.component.html'
})

export class FindSubtextComponent {
  public allMatches: string;
  public url: string;
  public fullText: string;
  public subText: string;
  public IsSucessMessageVisible: boolean = true;
  public IsErrorMessageVisible: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  public searchSubtextInText(fullText, subText) {
    let param: any = { 'text': fullText, 'subText': subText };

    this.http.get(this.url + 'FindSubtext', { params: param, responseType: 'text' }).subscribe(result => {
      this.allMatches = result;
      if (typeof this.allMatches != 'undefined' && this.allMatches) {
        this.IsErrorMessageVisible = false;
        this.IsSucessMessageVisible = true;
      } else {
        this.IsErrorMessageVisible = true;
        this.IsSucessMessageVisible = false;
      }
    }, error => console.error(error));;
  }

  public clear() {
    this.fullText = "";
    this.subText = "";
  }
}
