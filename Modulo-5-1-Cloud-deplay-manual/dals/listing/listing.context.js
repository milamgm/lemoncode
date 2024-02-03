import { db } from '#core/servers/index.js';
export const getListingContext = () => db?.collection('listingsAndReviews');
