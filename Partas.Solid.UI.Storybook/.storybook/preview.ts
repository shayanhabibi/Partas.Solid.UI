import './tailwind.css';

import type { Preview } from '@kachurun/storybook-solid-vite';

export const tags = ['autodocs'];

const preview: Preview = {
  parameters: {
    // automatically create action args for all props that start with "on"
    actions: { argTypesRegex: '^on.*' },
    controls: {
      matchers: {
        color: /(background|color)$/i,
        date: /Date$/,
      },
    },
    docs: {
      codePanel: true,
    },
  },
};

export default preview;
