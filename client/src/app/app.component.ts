import { Component } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { DuckDuckGoService } from 'src/services/search.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  title = 'duckduckgoclient';
  length = 0; 
  pageSizeOptions: number[] = [5, 10, 25, 100];

  // MatPaginator Output
  pageEvent: PageEvent | undefined;
  searchQuery = '';
  page: number = 0;
  pageSize: number = 10;

  showHistory: boolean = false;

  data: any;
  historyData: any;

  constructor(private searchService: DuckDuckGoService) {
    this.pageSize = this.pageSizeOptions[0];
    this.history();
  }

  search() {
    this.searchService.search(this.searchQuery, this.page, this.pageSize).subscribe(result => {
      this.data = result; 
      this.length = result.resultsCount;
      this.history();
    });
  }

  history() {
    this.searchService.history().subscribe(historyResult => {
      this.historyData = historyResult;
    });
  } 
  replayQuery(query: string) {
    this.searchQuery = query;
    this.page = 0;
    this.search();
  }
  onPaginatorChange(evt: any) {
    if(this.pageSize != evt.pageSize) {
      this.pageSize = evt.pageSize;
      this.page = 0;
    }
    else {
      this.page = evt.pageIndex;
    }
    this.search();
  }
}
