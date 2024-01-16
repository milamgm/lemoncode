import { envConstants } from '#core/constants/env.constants.js';
import { dbRepository } from './user.db-repository.js';
import { mockRepository } from './user.mock-repository.js';

export const userRepository = envConstants.isApiMock
  ? mockRepository
  : dbRepository;
