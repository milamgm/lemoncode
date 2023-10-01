/*Con el resultado del ejercicio 2, sustituye la función logUser por la siguiente y modifica el código aplicando las
guardas que creas conveniente para corregir los errores de compilación:*/

import { User } from "./Ejercicio2";
import { users } from "./Ejercicio2";

const logUser = (user: User) => {
  let extraInfo: string;
  if ("occupation" in user) {
    extraInfo = user.occupation;
  } else {
    extraInfo = user.subject;
  }
  console.log(`  - ${user.name}, ${user.age}, ${extraInfo}`);
};
