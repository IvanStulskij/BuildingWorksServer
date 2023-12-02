import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { selectProviderList } from 'src/app/store/selectors/provider.selector';
import { IAppState } from 'src/app/store/states/app.state';

@Component({
  selector: 'app-short-infos',
  templateUrl: './short-infos.component.html',
  styleUrls: ['./short-infos.component.scss']
})
export class ShortInfosComponent<T> implements OnInit {
  items$ = this.store.pipe(select(selectProviderList));

  constructor(private store: Store<IAppState>) { }

  ngOnInit(): void {
      //this.store.dispatch(new Get)
  }
}
