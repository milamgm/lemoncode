import { Schema, model } from 'mongoose';
import { User } from './user.model.js';


const userSchema = new Schema({
    _id: Schema.Types.ObjectId,
    email: Schema.Types.String,
    password: Schema.Types.String,
    salt: Schema.Types.String,
    role: Schema.Types.String,
})

export const userContext = model<User>('User', userSchema, "users");
