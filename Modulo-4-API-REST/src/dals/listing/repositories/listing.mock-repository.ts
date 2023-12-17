import { ObjectId } from 'mongodb';
import { ListingRepository } from './listing.repository.js';
import { Listing, Review } from '../listing.model.js';
import { db } from '../../airbnb.mock-data.js';

const insertListing = (listing: Listing) => {
  const _id = new ObjectId();
  const newListing: Listing = {
    ...listing,
    _id,
  };

  db.listingsAndReviews = [...db.listingsAndReviews, newListing];
  return newListing;
};

const updateReview = (_id: ObjectId, review: Review) => {
  db.listingsAndReviews = db.listingsAndReviews.map((b) =>
    b._id.toHexString() === _id.toHexString()
      ? { ...b, reviews: [...b.reviews, review] }
      : b
  );
  return review;
};

const paginatedListingList = (
  listingList: Listing[],
  page: number,
  pageSize: number
): Listing[] => {
  let paginatedListingList = [...listingList];
  if (page && pageSize) {
    const startIndex = (page - 1) * pageSize;
    const endIndex = Math.min(
      startIndex + pageSize,
      paginatedListingList.length
    );
    paginatedListingList = paginatedListingList.slice(startIndex, endIndex);
  }

  return paginatedListingList;
};

export const mockRepository: ListingRepository = {
  getListingList: async (page?: number, pageSize?: number) =>
    paginatedListingList(db.listingsAndReviews, page, pageSize),
  getListing: async (id: string) =>
    db.listingsAndReviews.find((b) => b._id.toHexString() === id),
  saveReview: async (id: string, review: Review) => {
    db.listingsAndReviews = db.listingsAndReviews.map((b) =>
      b._id.toHexString() === id
        ? { ...b, reviews: [...b.reviews, review] }
        : b
    );
    return review;
  },
};
