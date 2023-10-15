/**Mediante genéricos y tuplas, tipa de forma completa la función para solventar los errores de compilación.*/

const swap = <T, U>(arg1: T, arg2: U): [U, T] => {
  return [arg2, arg1];
};

let age: number, occupation: string;

[occupation, age] = swap(39, "Placement officer");
console.log("Occupation: ", occupation);
console.log("Age: ", age);
