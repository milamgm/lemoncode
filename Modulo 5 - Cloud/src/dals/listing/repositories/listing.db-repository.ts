import { ObjectId } from 'mongodb';
import { ListingRepository } from './listing.repository.js';
import { Listing, Review } from '../listing.model.js';
import { getListingContext } from '../listing.context.js';

export const dbRepository: ListingRepository = {
  getListingList: async (page?: number, pageSize?: number) => {
    const skip = Boolean(page) ? (page - 1) * pageSize : 0;
    const limit = pageSize ?? 0;
    return await getListingContext().find().skip(skip).limit(limit).toArray();
  },
  getListing: async (id: string) => {
    return await getListingContext().findOne({
      _id: new ObjectId(id),
    });
  },
  saveReview: async (id: string, review: Review) => {
    await getListingContext().findOneAndUpdate(
      {
        _id: new ObjectId(id),
      },
      {
        $push: {
          reviews: review,
        },
      },
      { upsert: true, returnDocument: 'after' }
    );
    return review;
  },
};
