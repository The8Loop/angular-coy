import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function intValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        const regex = /^(\+|-)?(\d+)$/;
        const validInt = regex.test(control.value);
        if (!validInt) {
            return { invalidInt: true };
        }
        else {
            return null;
        }
    };
}