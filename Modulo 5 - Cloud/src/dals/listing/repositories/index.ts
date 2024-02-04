import { mockRepository } from "./listing.mock-repository.js";
import { dbRepository } from "./listing.db-repository.js";
import { envConstants } from "#core/constants/index.js";

export const listingRepository = envConstants.isApiMock
  ? mockRepository
  : dbRepository;
