import { ObjectId } from 'mongodb';
import { envConstants } from '#core/constants/index.js';
import {
  connectToDBServer,
} from '#core/servers/index.js';
import { listingContext } from '#dals/listing/listing.context.js';
import {
  mapListingFromModelToApi,
  mapListingListFromModelToApi,
} from '#pods/listing/listing.mappers.js';
import inquirer from 'inquirer';

const addDemoReview = async () => {
  const res = await listingContext.findOneAndUpdate(
    {
      name: 'Ribeira Charming Duplex',
    },
    {
      $set: {
        reviews: [
          {
            _id: '657ed79b19cff0069cca2ca6',
            date: '2023-12-17T11:12:27.681Z',
            listing_id: '65097600a74000a4a4a22684',
            reviewer_id: '657ed79b19cff0069cca2ca5',
            reviewer_name: 'Anne',
            comments: 'Review from console runner',
          },
        ],
      },
    },
    {
      returnDocument: 'after',
    }
  );

  const result = mapListingFromModelToApi(res);
  console.log(result);
};
const getFirstFiveListings = async () => {
  const res = await listingContext.find().limit(5);
  const result = mapListingListFromModelToApi(res);
  console.log({ result });
};

const functionMap = {
  getFirstFiveListings,
  addDemoReview,
};

let exit = false;
const runQueries = async () => {
  while (!exit) {
    const answer = await inquirer.prompt({
      name: 'consoleRunner',
      type: 'list',
      message: 'Which query do you want to run?',
      choices: ['getFirstFiveListings', 'addDemoReview', 'exit'],
    });
    const selectedFunction = functionMap[answer.consoleRunner];
    if (selectedFunction) {
      await selectedFunction();
      await run();
    } else {
      exit = true;
    }
  }
};

export const run = async () => {
  await connectToDBServer(envConstants.MONGODB_URI);
  await runQueries();
};
