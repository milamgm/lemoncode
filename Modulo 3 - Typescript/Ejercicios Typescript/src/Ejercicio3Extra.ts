/**Extra: Crea dos funciones isStudent e isTeacher que apliquen la guarda y úsalas en la función logPerson.
 * Aplica tipado completo en la función (argumentos y valor de retorno). Utiliza is. */

import { User, Student, Teacher } from "./Ejercicio2";
import { users } from "./Ejercicio2";

const isStudent = (user: User): user is Student => "occupation" in user;
const isTeacher = (user: User): user is Teacher => "subject" in user;

const logUser = (user: User) => {
  let extraInfo: string;
  if (isStudent(user)) {
    extraInfo = user.occupation;
  } else {
    extraInfo = user.subject;
  }
  console.log(`  - ${user.name}, ${user.age}, ${extraInfo}`);
};
