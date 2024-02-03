import { ObjectId } from 'mongodb';
import { getListingContext } from '../listing.context.js';
export const dbRepository = {
    getListingList: async (page, pageSize) => {
        const skip = Boolean(page) ? (page - 1) * pageSize : 0;
        const limit = pageSize ?? 0;
        return await getListingContext().find().skip(skip).limit(limit).toArray();
    },
    getListing: async (id) => {
        return await getListingContext().findOne({
            _id: new ObjectId(id),
        });
    },
    saveReview: async (id, review) => {
        await getListingContext().findOneAndUpdate({
            _id: new ObjectId(id),
        }, {
            $push: {
                reviews: review,
            },
        }, { upsert: true, returnDocument: 'after' });
        return review;
    },
};
