const { ApolloServer } = require('apollo-server');
const { ApolloGateway, RemoteGraphQLDataSource } = require('@apollo/gateway');

class ErrorHandlingDataSource extends RemoteGraphQLDataSource {
    async didReceiveResponse({ response, request, context }) {
        if (response.errors) {
            context.errors.push(...response.errors);
        }
        return response;
    }

    async didEncounterError(error) {
        console.error('Error:', error);
        return error;
    }
}

const gateway = new ApolloGateway({
    serviceList: [
        { name: 'user', url: 'http://localhost:5187/graphql' },
        { name: 'review', url: 'http://localhost:5019/graphql' },
    ],
    buildService({ name, url }) {
        return new ErrorHandlingDataSource({ url });
    },
});

const server = new ApolloServer({
    gateway,
    subscriptions: false,
    context: () => ({ errors: [] }),
    formatError: (error) => {
        console.log(error);
        return error;
    },
    formatResponse: (response, requestContext) => {
        if (requestContext.context.errors.length > 0) {
            response.errors = requestContext.context.errors;
        }
        return response;
    },
    debug: true,
});

server.listen().then(({ url }) => {
    console.log(`🚀 Gateway ready at ${url}`);
});