import { ObjectId } from 'mongodb';
import { envConstants } from '#core/constants/index.js';
import {
  connectToDBServer,
  //disconnectFromDBServer,
} from '#core/servers/index.js';
import { listingContext } from '#dals/listing/listing.context.js';
import { mapListingListFromModelToApi } from '#pods/listing/listing.mappers.js';

const runQueries = async () => {
  const res = await listingContext.find();
  const result = mapListingListFromModelToApi(res);
  console.log({ result });
};

export const run = async () => {
  await connectToDBServer(envConstants.MONGODB_URI);
  await runQueries();
  // await disconnectFromDBServer();
};
