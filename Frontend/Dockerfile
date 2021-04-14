FROM nginx:alpine
COPY /dist/Frontend /usr/share/nginx/html

RUN rm -rf /etc/nginx/conf.d/default.conf
COPY ./nginx-kong-proxy.conf /etc/nginx/conf.d