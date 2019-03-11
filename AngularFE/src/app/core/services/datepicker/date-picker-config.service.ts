import {Injectable} from '@angular/core';
import {DatepickerOptions} from 'ng2-datepicker';

@Injectable()
export class DatePickerConfigService
{
  public getConfig() : DatepickerOptions
  {
    return {
      minYear: 1970,
      maxYear: 2030,
      displayFormat: 'DD-MM-YYYY',
      firstCalendarDay: 1,
    };
  }
}
