import { Router } from 'express';
import { listingRepository } from '#dals/index.js';
import { mapListingListFromModelToApi, mapListingFromModelToApi, mapReviewFromApiToModel, } from './listing.mappers.js';
export const listingsApi = Router();
listingsApi
    .get('/', async (req, res, next) => {
    try {
        const page = Number(req.query.page);
        const pageSize = Number(req.query.pageSize);
        const listingList = await listingRepository.getListingList(page, pageSize);
        res.send(mapListingListFromModelToApi(listingList));
    }
    catch (error) {
        next(error);
    }
})
    .get('/:id', async (req, res, next) => {
    try {
        const { id } = req.params;
        const listing = await listingRepository.getListing(id);
        if (listing) {
            res.send(mapListingFromModelToApi(listing));
        }
        else {
            res.sendStatus(404);
        }
    }
    catch (error) {
        next(error);
    }
})
    .put('/add_review/:id', async (req, res, next) => {
    try {
        const { id } = req.params;
        if (await listingRepository.getListing(id)) {
            const review = mapReviewFromApiToModel({ ...req.body, listing_id: id });
            if (review) {
                await listingRepository.saveReview(id, review);
                res.sendStatus(204);
            }
            else {
                res.sendStatus(400);
            }
        }
        else {
            res.sendStatus(404);
        }
    }
    catch (error) {
        next(error);
    }
});
