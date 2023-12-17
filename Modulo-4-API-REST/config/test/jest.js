export default {
    rootDir: '../../',
    verbose: true,
    transform: {
      '^.+\\.tsx?$': [
        'ts-jest',
        {
          useESM: true,
        },
      ],
    },
    extensionsToTreatAsEsm: ['.ts'],
    moduleNameMapper: {
      '^(\\.{1,2}/.*)\\.js$': '$1',
    },
  };
  