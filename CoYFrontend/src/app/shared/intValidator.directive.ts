import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

/**
 * Validator function for checking if input is an integer
 * @returns Returns errors if input contains a decimal, or if input is not a positive or negative integer, otherwise returns null.
 */
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