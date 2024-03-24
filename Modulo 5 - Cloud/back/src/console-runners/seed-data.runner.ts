import { generateSalt, hashPassword } from '#common/helpers/index.js';
import {
  connectToDBServer,
  disconnectFromDBServer,
} from '#core/servers/index.js';
import { envConstants } from '#core/constants/index.js';
import { getListingContext } from '#dals/listing/listing.context.js';
import { getUserContext } from '#dals/user/user.context.js';
import { db } from '#dals/airbnb.mock-data.js';

export const run = async () => {
  await connectToDBServer(envConstants.MONGODB_URI);

  for (const user of db.users) {
    const salt = await generateSalt();
    const hashedPassword = await hashPassword(user.password, salt);

    await getUserContext().insertOne({
      ...user,
      password: hashedPassword,
      salt,
    });
  }

 // await getListingContext().insertMany(db.books);
  await disconnectFromDBServer();
};
