import { ObjectId } from 'mongodb';
import { db } from '../../airbnb.mock-data.js';
const insertListing = (listing) => {
    const _id = new ObjectId();
    const newListing = {
        ...listing,
        _id,
    };
    db.listingsAndReviews = [...db.listingsAndReviews, newListing];
    return newListing;
};
const updateReview = (_id, review) => {
    db.listingsAndReviews = db.listingsAndReviews.map((b) => b._id.toHexString() === _id.toHexString()
        ? { ...b, reviews: [...b.reviews, review] }
        : b);
    return review;
};
const paginatedListingList = (listingList, page, pageSize) => {
    let paginatedListingList = [...listingList];
    if (page && pageSize) {
        const startIndex = (page - 1) * pageSize;
        const endIndex = Math.min(startIndex + pageSize, paginatedListingList.length);
        paginatedListingList = paginatedListingList.slice(startIndex, endIndex);
    }
    return paginatedListingList;
};
export const mockRepository = {
    getListingList: async (page, pageSize) => paginatedListingList(db.listingsAndReviews, page, pageSize),
    getListing: async (id) => db.listingsAndReviews.find((b) => b._id.toHexString() === id),
    saveReview: async (id, review) => {
        db.listingsAndReviews = db.listingsAndReviews.map((b) => b._id.toHexString() === id
            ? { ...b, reviews: [...b.reviews, review] }
            : b);
        return review;
    },
};
