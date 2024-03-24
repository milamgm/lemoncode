import { Router } from 'express';
import jwt from 'jsonwebtoken';
import { UserSession } from '#common-app/models/index.js';
import { envConstants } from '#core/constants/index.js';
import { userRepository } from '#dals/index.js';

export const securityApi = Router();

securityApi.post('/login', async (req, res, next) => {
  try {
    const { email, password } = req.body;
    const user = await userRepository.getUserByEmailAndPassword(
      email,
      password
    );
    if (user) {
      const userSession: UserSession = {
        id: user._id.toHexString(),
        role: user.role,
      };
      const token = jwt.sign(userSession, envConstants.AUTH_SECRET, {
        expiresIn: '1d',
        algorithm: 'HS256',
      });
      res.cookie('authorization', `Bearer ${token}`, {
        httpOnly: true,
        secure: envConstants.isProduction,
      });
      res.sendStatus(204);
    } else {
      res.sendStatus(401);
    }
  } catch (error) {
    next(error);
  }
});

securityApi.post('/logout', async (req, res, next) => {
  res.clearCookie('authorization');
  res.sendStatus(200);
});
