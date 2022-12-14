import {FormControl} from "@angular/forms";

export class ProfileValidators {
  static weightValueValidator  (control: FormControl)  {

    if(control.value < 40 || control.value > 150) {
      return {weightValueValidator: 'Невірно введені дані, спробуйте від 40 до 150 включно'}
    }
    return null
  }
  static heightValueValidator  (control: FormControl)  {
    if(control.value < 150 || control.value > 250) {
      return {heightValueValidator: 'Невірно введені дані, спробуйте від 150 до 250 включно'}
    }
    return null
  }
  static footSizeValueValidator (control: FormControl)  {
    if(control.value < 0 || control.value > 47) {
      return {footSizeValueValidator: 'Невірно введені дані, спробуйте від 38 до 47 включно'}
    }
    return null
  }
  static headSizeValueValidator  (control: FormControl)  {
    if(control.value < 54 || control.value > 64) {
      return {headSizeValueValidator: 'Невірно введені дані, спробуйте від 54 до 64 включно'}
    }
    return null
  }
  static gasMaskSizeValueValidator  (control: FormControl)  {
    if(control.value < 0 || control.value > 4) {
      return {gasMaskSizeValidator: 'Невірно введені дані, спробуйте від 0 до 4 включно'}
    }
    return null
  }
}
