FROM node:18.17-alpine AS build

WORKDIR /app

COPY package*.json ./

RUN npm install -g @angular/cli@17.2.2
RUN npm install
RUN npx ngcc --properties es2023 browser module main --first-only --create-ivy-entry-points

COPY . .

RUN npm run build

EXPOSE 4200

CMD ["ng", "serve", "--host", "0.0.0.0"]
