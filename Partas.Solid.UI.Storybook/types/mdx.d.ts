// mdx.d.ts
/// <reference types="react" />
declare module '*.mdx' {
    import * as React from 'react';

    const MDXComponent: React.FC;

    export default MDXComponent;
}
