import { userContext } from '../user.context.js';
import { UserRepository } from './user.repository.js';

export const dbRepository: UserRepository = {
  getUserByEmailAndPassword: async (email: string, password: string) => {
    return await userContext.findOne({
      email,
    });
  },
};
