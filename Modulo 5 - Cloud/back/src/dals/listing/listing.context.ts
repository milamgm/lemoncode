import { db } from '#core/servers/index.js';
import { Listing } from './listing.model.js';

export const getListingContext = () => db?.collection<Listing>('listingsAndReviews');
