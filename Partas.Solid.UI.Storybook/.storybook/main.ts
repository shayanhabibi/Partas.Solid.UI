import { mergeConfig } from 'vite';
import type { StorybookConfig } from '@kachurun/storybook-solid-vite';

export default {
  framework: '@kachurun/storybook-solid-vite',
  addons: [
    '@storybook/addon-onboarding',
    '@storybook/addon-docs',
    '@storybook/addon-a11y',
    '@storybook/addon-links',
    {
      name: '@storybook/addon-vitest',
      options: {
        cli: false,
      },
    },
  ],
  stories: [
    '../stories/**/*.mdx',
    '../stories/**/*.stories.@(js|jsx|mjs|ts|tsx)',
  ],
  async viteFinal(config) {
    return mergeConfig(config, {
      define: {
        'process.env': {},
      },
      plugins: [(await import('@tailwindcss/vite')).default()],
    });
  },
} as StorybookConfig;
