FROM node:18

WORKDIR /app

COPY package*.json ./

RUN npm install && npm install jade

COPY . .

ENV PORT=8888
ENV PORT_REDIS=6379
ENV HOST=52.77.78.167
ENV DATABASE=star_security
ENV DB_NAME=huynn
ENV DB_PASS=Huynn@9890#!
ENV DIALECT=mysql
ENV ACCESS_TOKEN_SECRET=asd9asd8a9f8af.sad0fas8das9d8as90da
ENV REFRESH_TOKEN_SECRET=as0dq9we8we9dd89f7sdf7s.asdfsd0f9sd8fsd8fsdf67s
ENV expire_Cookie=24*60*60*1000
ENV EMAIL_USER=
ENV EMAIL_PASS=root@ee0b1957fe71

EXPOSE 8888

CMD [ "npm", "start" ]