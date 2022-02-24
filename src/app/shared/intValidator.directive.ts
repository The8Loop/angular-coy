import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function intValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        const regex = /^(\+|-)?\d+(\.)+\d*$/;
        const hasDecimal = regex.test(control.value);

        if (hasDecimal) {
            return { decimalDetected: true }
        }
        else if (!Number.isInteger(control.value)) {
            return { invalidInt: true }
        }
        else {
            return null;
        }
    };
}