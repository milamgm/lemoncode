import { ObjectId } from 'mongodb';
import { ListingRepository } from './listing.repository.js';
import { Listing, Review } from '../listing.model.js';
import { listingContext } from '../listing.context.js';

export const dbRepository: ListingRepository = {
  getListingList: async (page?: number, pageSize?: number) => {
    const skip = Boolean(page) ? (page - 1) * pageSize : 0;
    const limit = pageSize ?? 0;
    return await listingContext.find().skip(skip).limit(limit).lean();
  },
  getListing: async (id: string) => {
    return await listingContext.findOne({
      _id: new ObjectId(id),
    }).lean();
  },
  saveReview: async (id: string, review: Review) => {
    await listingContext.findOneAndUpdate(
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
